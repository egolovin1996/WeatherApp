const baseUrl = "api/weather/";

function baseRequest(url) {
    return fetch(`${baseUrl}${url}`).then(response => {
        const data = response && response.json();
        if (response.ok) {
            return data;
        }

        const error = (data && data.error) || response.statusText;
        console.log("Error: " + error);

        return Promise.reject(error);
    });
}

function getWeatherByCityName(name, daysCount) {
    return baseRequest(`getWeatherByCityName/${name}/${daysCount}`);
}

function getWeatherByCoords(latitude, longitude, daysCount) {
    return baseRequest(`getWeatherByCoords/${latitude}/${longitude}/${daysCount}`);
}

export default {
    getWeatherByCityName,
    getWeatherByCoords
};
