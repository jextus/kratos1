// Archivo codificado en UTF-8
import React from 'react';
import { Link } from 'react-router-dom';
import './Home.css'; // Archivo de estilos que crearemos despu�s

function Home() {
  return (
    <div className="home-container">
      {/* Hero Section */}
      <header className="hero-section">
        <div className="hero-content">
          <h1 className="hero-title">Bienvenido a Kratos App</h1>
          <p className="hero-subtitle">Tu soluci�n integral para gesti�n y productividad</p>
          <div className="hero-buttons">
            <Link to="/login" className="btn btn-primary">Iniciar Sesi�n</Link>
            <Link to="/register" className="btn btn-secondary">Registrarse</Link>
          </div>
        </div>
        <div className="hero-image">
          {/* Puedes reemplazar esto con una imagen real */}
          <div className="placeholder-image"></div>
        </div>
      </header>

      {/* Features Section */}
      <section className="features-section">
        <h2 className="section-title">Nuestras Caracter�sticas</h2>
        <div className="features-grid">
          <div className="feature-card">
            <div className="feature-icon">??</div>
            <h3>R�pido y Eficiente</h3>
            <p>Tecnolog�a de vanguardia para m�xima productividad.</p>
          </div>
          <div className="feature-card">
            <div className="feature-icon">??</div>
            <h3>Seguridad Garantizada</h3>
            <p>Tus datos siempre protegidos con cifrado avanzado.</p>
          </div>
          <div className="feature-card">
            <div className="feature-icon">??</div>
            <h3>Sincronizaci�n en Tiempo Real</h3>
            <p>Tus datos actualizados en todos tus dispositivos.</p>
          </div>
        </div>
      </section>

      {/* Testimonials Section */}
      <section className="testimonials-section">
        <h2 className="section-title">Lo que dicen nuestros usuarios</h2>
        <div className="testimonials-grid">
          <div className="testimonial-card">
            <p>"Esta aplicaci�n ha transformado completamente mi flujo de trabajo."</p>
            <div className="testimonial-author">- Mar�a G.</div>
          </div>
          <div className="testimonial-card">
            <p>"La mejor inversi�n que he hecho para mi negocio este a�o."</p>
            <div className="testimonial-author">- Carlos R.</div>
          </div>
        </div>
      </section>

      {/* Call to Action */}
      <section className="cta-section">
        <h2>�Listo para comenzar?</h2>
        <p>�nete a miles de usuarios satisfechos hoy mismo.</p>
        <Link to="/register" className="btn btn-large">Reg�strate Gratis</Link>
      </section>
    </div>
  );
}

export default Home;