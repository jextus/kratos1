     // src/api/axios.js
     import axios from 'axios';

     const api = axios.create({
       baseURL: 'http://localhost:5000/api', // Cambia esto según tu configuración
     });

     export default api;
     