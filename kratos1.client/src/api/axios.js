import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000/api', // Aseg�rate que coincida con tu backend
});

// Interceptor para a�adir el token a las solicitudes
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Interceptor para manejar errores globales
api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      // Redirigir a login si el token es inv�lido o expir�
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      localStorage.removeItem('empresa');
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);

export default api;