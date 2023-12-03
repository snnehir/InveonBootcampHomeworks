import * as React from 'react';
import { connect, useDispatch } from 'react-redux';
import { useEffect } from 'react';
import { useNavigate } from "react-router-dom";
import userManager from '../app/UserManager';
import axios from 'axios';

const CallbackPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const successCallback = (user) => {
    // get the user's previous location, passed during signinRedirect()
    const redirectPath = user.state.path;
    const userProfile = {
      name: user.profile.name,
      role: user.profile.role,
      email: user.profile.preferred_username,
      id_token: user.id_token,
    }
    dispatch({ type: "user/login", payload: { user: userProfile, status: true } })
    axios.defaults.headers.common['Authorization'] = 'Bearer ' + user.access_token;
    navigate(redirectPath);
  };

  const errorCallback = (error) => {
    //console.log("err callback: ", error);
    navigate('/');
  };

  useEffect(() => {
    userManager
      .signinRedirectCallback()
      .then(user => successCallback(user))
      .catch(error => errorCallback(error));
  });

  return <div>Yükleniyor...</div>;
};

export default connect()(CallbackPage);
