import React, { Component } from "react";
import {
    Area,
    AreaChart,
    ResponsiveContainer,
    Tooltip,
    XAxis,
    YAxis,
    CartesianGrid
} from "recharts";

export default class Chart extends Component {
    render() {
        return (
            <div>
                <div className="d-flex flex-column bd-highlight mb-3">
                    <ResponsiveContainer width="100%" aspect={7.0 / 1.5}>
                        <AreaChart data={this.props.forecasts}>
                            <Area
                                type="monotone"
                                dataKey="main.temp"
                                name="Temperature"
                                stroke="#696969"
                                fill="#B8B8B8"
                            />
                            <XAxis dataKey="dt_txt" />
                            <CartesianGrid />
                            <YAxis />
                            <Tooltip />
                        </AreaChart>
                    </ResponsiveContainer>
                </div>
            </div>
        );
    }
}
