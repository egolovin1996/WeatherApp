import React, { Component } from "react";
import Table from "./Table";
import Chart from "./Chart";
import Loader from "react-loader-spinner";
import weatherService from "./services/weatherService";

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            forecasts: [],
            loading: true,
            cityName: "Yekaterinburg",
            daysCount: 2
        };
    }

    async componentDidMount() {
        if (this.props.name) {
            this.setStateByCityName(this.props.name);
            return;
        }

        navigator.geolocation.getCurrentPosition(
            async position => {
                const data = await weatherService.getWeatherByCoords(
                    position.coords.latitude,
                    position.coords.longitude,
                    this.state.daysCount
                );
                this.setState({
                    forecasts: data.list,
                    loading: false,
                    cityName: data.city.name
                });
            },
            () => this.setStateByCityName(this.state.cityName)
        );
    }

    async setStateByCityName(cityName) {
        const data = await weatherService.getWeatherByCityName(
            cityName,
            this.state.daysCount
        );
        this.setState({
            forecasts: data.list,
            loading: false,
            cityName: data.city.name
        });
    }

    render() {
        return this.state.loading ? (
            <div
                style={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    minHeight: "80vh"
                }}
            >
                <Loader type="ThreeDots" color="black" height={80} width={80} />
            </div>
        ) : (
            <div>
                <div className="d-flex flex-column bd-highlight mb-3">
                    <h1>
                        Weather forecast in {this.state.cityName} for {this.state.daysCount}{" "}
                        days
                    </h1>
                </div>
                <Chart forecasts={this.state.forecasts} />
                <Table forecasts={this.state.forecasts} />
            </div>
        );
    }
}
