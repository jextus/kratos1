import React from 'react';
import { useNavigate } from 'react-router-dom';

const Unauthorized = () => {
  const navigate = useNavigate();

  return (
    <div className="unauthorized-container">
      <h1>No Autorizado</h1>
      <p>No tienes permisos para acceder a esta p�gina.</p>
      <button onClick={() => navigate(-1)}>Volver atr�s</button>
      <button onClick={() => navigate('/dashboard')}>Ir al Dashboard</button>
    </div>
  );
};

export default Unauthorized;