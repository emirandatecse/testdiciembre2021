export async function authFetch(url, params) {
    const paramsTemp = {
      ...params,
      headers: {
        ...params?.headers,
      },
    };
    try {
      const response = await fetch(url, paramsTemp);
      const result = await response.json();
      return result;
    } catch (error) {
      return error;
    }
}