import React, { Component } from 'react';
import {
    ResponsiveContainer, AreaChart, Area, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend,
} from 'recharts';

export class Home extends Component {
  static displayName = Home.name;

  constructor (props) {
    super(props);
    this.state = { forecasts: [], loading: true, cityName: "Moscow", latitude: 0, longitude: 0 };

    navigator.geolocation.getCurrentPosition(position => {
        console.log(position);
        fetch('api/weather/getWeatherByCoords/' + position.coords.latitude + '/'+ position.coords.longitude)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ forecasts: data.list, loading: false, cityName: data.city.name });
            });
    }, () => {
        fetch('api/weather/getWeatherByCityName/' + this.state.cityName)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ forecasts: data.list, loading: false, cityName: data.city.name });
            });
    });
  }

  static renderForecastsTable (forecasts) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.dt}>
              <td>{forecast.dt_txt}</td>
              <td>{forecast.main.temp}</td>
              <td>{forecast.weather[0].main}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Home.renderForecastsTable(this.state.forecasts);

      return (
          <div >
              <h1>Weather forecast in {this.state.cityName}</h1>
              <div className="inline">
                  
                      <AreaChart
                          width={1000}
                          height={200}
                          data={this.state.forecasts}
                      >
                          <Area type="monotone" dataKey="main.temp" fill="#8884d8" />
                          <XAxis dataKey="dt_txt" />
                          <YAxis />
                          <Tooltip />
                      </AreaChart>
                  
                  {contents}
              </div>
          </div>
      );
  }
}
