const ENV = {
  dev: {
    apiUrl: 'http://localhost:44317',
    oAuthConfig: {
      issuer: 'http://localhost:44317',
      clientId: 'Healthcare_App',
      clientSecret: '1q2w3e*',
      scope: 'Healthcare',
    },
    localization: {
      defaultResourceName: 'Healthcare',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44317',
    oAuthConfig: {
      issuer: 'http://localhost:44317',
      clientId: 'Healthcare_App',
      clientSecret: '1q2w3e*',
      scope: 'Healthcare',
    },
    localization: {
      defaultResourceName: 'Healthcare',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
