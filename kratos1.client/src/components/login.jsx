          
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    try {
      if (email && password) {
        navigate('/dashboard');
      } else {
        setError('Por favor ingresa email y contrase�a');
      }
    } catch {
      setError('Error al iniciar sesi�n. Por favor verifica tus credenciales.');
    }
  };

  return (
    <div className="login-container">
      <div className="login-form">
        <h2>Iniciar Sesi�n</h2>
        {error && <div className="error-message">{error}</div>}
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="password">Contrase�a:</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          <button type="submit" className="login-button">Ingresar</button>
        </form>
        <div className="login-links">
          <a href="/forgot-password">�Olvidaste tu contrase�a?</a>
          <a href="/register">�No tienes cuenta? Reg�strate</a>
        </div>
      </div>
    </div>
  );
};

export default Login;
