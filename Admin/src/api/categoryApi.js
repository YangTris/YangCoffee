import axios from 'axios';

const API_BASE_URL = 'https://localhost:7192/api';

export const getAllCategories = async () => {
  const response = await axios.get(`${API_BASE_URL}/Categories`);
  return response.data;
};

export const getCategoryById = async (id) => {
  const response = await axios.get(`${API_BASE_URL}/Categories/${id}`);
  return response.data;
};

export const addCategory = async (category) => {
  const response = await axios.post(`${API_BASE_URL}/Categories`, category);
  return response.data;
};

export const updateCategory = async (id, category) => {
  await axios.put(`${API_BASE_URL}/Categories/${id}`, category);
};

export const deleteCategory = async (id) => {
  await axios.delete(`${API_BASE_URL}/Categories/${id}`);
};
