import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect, Link } from "react-router-dom";

import "./assents/css/style.css";

import NaoEncontrada from "./pages/naoEncontrada/naoEncontrada";
import App from './pages/home/App';
import Login from "./pages/login/login";
import Cadastro from "./pages/cadastro/cadastro"

import * as serviceWorker from './serviceWorker';

const Permissao = ({ component: Component }, { ...rest }) => (
  <Route
    {...rest}
    render={props => localStorage.getItem("usuariotoken-wishlist") != null ?
      <Component {...props} /> :
      <Redirect to={{ pathname: "/login" }} />
    }
  />
);

const Routing = (
  <Router>
    <div>
      <Switch>
        <Permissao exact path="/" component={App} />
        <Route path="/login" component={Login} />
        <Route path="/cadastro" component={Cadastro} />
        <Route component={NaoEncontrada} />
        <Link to="/cadastro" component={Cadastro} />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(Routing, document.getElementById('root'));

serviceWorker.unregister();
