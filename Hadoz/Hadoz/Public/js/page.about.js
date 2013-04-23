var _gmapInit = false;

$(document).ready(function() {

    /* --------------------------------------------------------------------------- */
    /*  Easytabs
    /* --------------------------------------------------------------------------- */
    $('#aboutme').easytabs();
    $('#subnavigation').easytabs();

    /* --------------------------------------------------------------------------- */
    /*  Contact Form
    /* --------------------------------------------------------------------------- */

    var $contactform        = $('#contactform'),
        $success            = 'Your message was successfully sent.';

    // Validate form on keyup and submit
    $contactform.validate({
        rules: {
            name: {
                required    : true,
                minlength   : 1
            },
            email: {
                required    : true,
                email       : true
            },
            message: {
                required    : true,
                minlength   : 1
            }
        },
        messages: {
            name: {
                required    : "Please enter your name.",
                minlength   : jQuery.format("Your name needs to be at least {0} characters")
            },
            email: {
                required    : "Please enter a valid email address.",
                minlength   : "Please enter a valid email address"
            },
            message: {
                required    : "You need to enter a message.",
                minlength   : jQuery.format("Enter at least {0} characters")
            }
        }
    });

    // Send the email
    $contactform.submit(function(){
        if ($contactform.valid()){
            $.ajax({
                type: "POST",
                url: "/contact.php",
                data: $(this).serialize(),
                success: function(msg) {
                    if (msg == 'SEND') {
                        response = '<div class="success">'+ $success +'</div>';
                    }
                    else {
                        response = '<div class="error">'+ msg +'</div>';
                    }
                    $(".error,.success").remove();
                    $contactform.prepend(response);
                }
             });
            return false;
        }
        return false;
    });


    /* --------------------------------------------------------------------------- */
    /*  In-Field Labels
    /* --------------------------------------------------------------------------- */
    $(function(){
        $(".flabel").inFieldLabels();
    });

    /* --------------------------------------------------------------------------- */
    /*  Init Google Map
    /* --------------------------------------------------------------------------- */
    if ( document.location.hash.substr(1) == 'contact' ) {
        initGmap();
    } else {
        $(window).hashchange( function(){
            if ( document.location.hash.substr(1) == 'contact' ) {
                initGmap();
            }
        });
    }
});

function initGmap() {
    if ( !_gmapInit ) {
        _gmapInit = true;
        var wmarker = new google.maps.MarkerImage(
            'images/wmarker.png',
            new google.maps.Size(43,63),
            new google.maps.Point(0,0),
            new google.maps.Point(21,63)
        );

        var myOptions = {center: new google.maps.LatLng(40.79, -73.96),
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            panControl: true,
            overviewMapControl: false,
            mapTypeControl: false,
            scaleControl: false,
            streetViewControl: false
        };

        $("#gmap").gmap3({
            map:{
                options: myOptions
            },
            marker:{
                latLng: [40.781029, -73.967171],
                options:{
                    icon: wmarker
                }
            }
        });
    }
}
