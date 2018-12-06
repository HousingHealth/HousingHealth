// Global Variables
var delay = 100;
var infowindow = new google.maps.InfoWindow();
var latlng = new google.maps.LatLng(40.367474, -82.996216); //Ohio coordinates
var mapOptions = {
    zoom: 5,
    center: latlng,
    mapTypeId: google.maps.MapTypeId.ROADMAP
}
var geocoder = new google.maps.Geocoder();
var map = new google.maps.Map(document.getElementById('gmap_canvas'), mapOptions);
var bounds = new google.maps.LatLngBounds();
var locations = [
    '601 Lakeside Ave, Cleveland, OH',
    '3409 Woodland Ave., Cleveland, OH',
    '1300 Crestline Ave, Cleveland, OH ',
    '10900 Euclid Ave, Cleveland, OH',
    '5300 Riverside Dr, Cleveland, OH',
    '11030 East Blvd, Cleveland, OH',
    '2000 Sycamore St, Cleveland, OH',
    '3900 Wildlife Way, Cleveland, OH',
    '601 Erieside Ave, Cleveland, OH',
    'Public Square, Cleveland, OH'

];
var nextAddress = 0;

// Main Function
Main();

// Functions

function Main() {
    if (nextAddress < locations.length) {
        setTimeout('geocodeAddress("' + locations[nextAddress] + '",Main)', delay);
        nextAddress++;
    } else {
        map.fitBounds(bounds);
    }
}

function geocodeAddress(address, next) {
    geocoder.geocode({ address: address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var p = results[0].geometry.location;
            var lat = p.lat();
            var lng = p.lng();
            createMarker(address, lat, lng);
        }
        else {
            if (status == google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                nextAddress--;
                delay++;
            } else {
            }
        }
        next();
    }
    );
}
function createMarker(add, lat, lng) {
    var contentString = add;
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(lat, lng),
        map: map,
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(contentString);
        infowindow.open(map, marker);
    });

    bounds.extend(marker.position);

}



