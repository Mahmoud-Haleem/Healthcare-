export const environment = {
  production: true,
  application: {
    name: 'Healthcare',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44317',
    clientId: 'Healthcare_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'Healthcare',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44317',
    },
  },
  localization: {
    defaultResourceName: 'Healthcare',
  },
};
