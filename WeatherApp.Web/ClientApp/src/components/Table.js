import React, { Component } from "react";

export default class Table extends Component {
    render() {
        return (
            <div className="d-flex flex-column-reverse bd-highlight">
                <table className="table table-striped">
                    <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Summary</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.props.forecasts.map(forecast => (
                        <tr key={forecast.dt}>
                            <td>{forecast.dt_txt}</td>
                            <td>{forecast.main.temp}</td>
                            <td>{forecast.weather[0].main}</td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        );
    }
}
