import { createUserManager } from 'redux-oidc';

const userManagerConfig = {
  client_id: 'inveon',
  authority: "https://localhost:44365",
  redirect_uri: 'http://localhost:3000/callback',
  response_type: 'code',
  scope: "openid profile inveon",
  client_secret: "secret",
  post_logout_redirect_uri: "http://localhost:3000/signout-callback-oidc",
  filterProtocolClaims: true,
  loadUserInfo: true,
  monitorSession: true,
  automatic_redirect_after_signout: true,

};

const userManager = createUserManager(userManagerConfig);

export default userManager;