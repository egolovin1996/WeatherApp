import React, { Component } from "react";

export default class Table extends Component {
    render() {
        return (
            <div className="d-flex flex-column-reverse bd-highlight">
                <table className="table table-striped">
                    <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temperature (C)</th>
                        <th>Wind speed (meter/sec)</th>
                        <th>Description</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.props.forecasts.map(forecast => (
                        <tr key={forecast.dt}>
                            <td>{forecast.dt_txt}</td>
                            <td>{forecast.main.temp}</td>
                            <td>{forecast.wind.speed}</td>
                            <td>{forecast.weather[0].description}</td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        );
    }
}
