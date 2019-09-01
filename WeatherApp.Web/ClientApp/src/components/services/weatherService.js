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

function getWeatherByCityName(name) {
    return baseRequest(`getWeatherByCityName/${name}`);
}

function getWeatherByCoords(latitude, longitude) {
    return baseRequest(`getWeatherByCoords/${latitude}/${longitude}`);
}

export default {
    getWeatherByCityName,
    getWeatherByCoords
};
