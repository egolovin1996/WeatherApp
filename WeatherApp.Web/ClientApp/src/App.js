import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path="/" component={Home} />
                <Route path="/moscow" component={() => <Home name="Moscow" />} />
                <Route path="/london" component={() => <Home name="London" />} />
                <Route path="/paris" component={() => <Home name="Paris" />} />
            </Layout>
        );
    }
}
