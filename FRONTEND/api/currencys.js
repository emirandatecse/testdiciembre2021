import { BASE_API, BASE_API_TOKEN } from "../utils/constants";
import { authFetch } from "../utils/fetch";

export async function getToken() {
   try {
    const url = `${BASE_API_TOKEN}`;
    const result = await authFetch(url, null);
    return result;
  } catch (error) {
    return null;
  }
}

export async function getMoneys(data, token) {
  
  
  try {
    const url = `${BASE_API}/search`;
    const params = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify(data),
      };
    const result = await authFetch(url, params);
    return result?.listCurrencyExchange == null ? [] : result.listCurrencyExchange;
  } catch (error) {
    return null;
  }
}
export async function getCurrencyExchange(data, token) {
    try {
      const url = `${BASE_API}/search`;
      const params = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
              },
            body: JSON.stringify(data),
            };
      const result = await authFetch(url, params);
      const resultCurrency =  result?.listCurrencyExchange == null ? [] : result.listCurrencyExchange[0];
      return resultCurrency;
    } catch (error) {
      return null;
    }
}