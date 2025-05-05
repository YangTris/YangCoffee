import axios from 'axios';

const API_BASE_URL = 'https://localhost:7192';

export const getAllCustomer = async () => {
  const response = await axios.get(`${API_BASE_URL}/api/Customers`);
  return response.data;
};

export const login = async (credentials) => {
  const response = await axios.post(`${API_BASE_URL}/login`, credentials, {
    headers: {
      'Content-Type': 'application/json',
    },
  });
  return response;
};