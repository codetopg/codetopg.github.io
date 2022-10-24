var getLocationInterop = {};

getLocationInterop.getLocation = async function () {
    function getPositionAsync() {
        return new Promise((success, error) =>
        {navigator.geolocation.getCurrentPosition(success, error) });
    }
    if (navigator.geolocation) {
        var position = await getPositionAsync();
        var coords = {
            longitude: position.coords.longitude,
            latitude: position.coords.latitude
        }
        return coords
    } else { throw Error="Browser not support Geo location!" }
}