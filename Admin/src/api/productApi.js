import axios from 'axios';

const API_BASE_URL = 'https://localhost:7192/api';

// export const getProductById = async (id) => {
//     const response = await axios.get(`${API_BASE_URL}/Products/${id}`);
//     return response.data;
// };

export const addProduct = async (product) => {
    const response = await axios.post(`${API_BASE_URL}/Products`, product);
    return response.data;
};

export const updateProduct = async (id, product) => {
    await axios.put(`${API_BASE_URL}/Products/${id}`, product);
};

export const searchProducts = async ({
    searchName,
    sortBy,
    isDescending,
    pageNumber,
    pageSize,
}) => {
    const params = {
        searchName,
        sortBy,
        isDescending,
        pageNumber,
        pageSize,
    };

    // Remove undefined/null keys
    Object.keys(params).forEach(
        (key) => params[key] == null && delete params[key]
    );

    const response = await axios.get(`${API_BASE_URL}/Products/search`, { params });
    return response.data;
};

export const deleteProduct = async (id) => {
    await axios.delete(`${API_BASE_URL}/Products/${id}`);
};
