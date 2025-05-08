import axios from 'axios';

const API_BASE_URL = 'https://localhost:7192/api';

export const getAllOrders = async () => {
  const response = await axios.get(`${API_BASE_URL}/Orders`);
  return response.data;
};