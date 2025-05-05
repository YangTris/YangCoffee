import React, { useState } from 'react';
import {login} from '../api/userAPI';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  //Login
  const [newLogin, setNewLogin] = useState({
    email: '',
    password: '',
  });

  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await login(newLogin);
      console.log('Login successful:', response.data);
      //Store token in sessionStorage
      sessionStorage.setItem('token', response.data.accessToken);

      navigate('/dashboard');
    } catch (error) {
      console.error('Login failed:', error.response?.data || error.message);
      alert('Invalid email or password');
    }
  };

  return (
    <div className="container d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
      <div className="card p-4 shadow-sm border rounded" style={{ width: '100%', maxWidth: 450 }}>
        <h2 className="text-center fw-bold">Admin Login</h2>
        <p className="text-center text-muted mb-4">Enter your credentials to access the dashboard</p>

        <form>
          {/* Email */}
          <div className="mb-3">
            <label htmlFor="email" className="form-label">Email</label>
            <div className="input-group">
              <span className="input-group-text">
                <i className="bi bi-envelope"></i>
              </span>
              <input
                type="email"
                id="email"
                className="form-control"
                placeholder="name@example.com"
                value={newLogin.email}
                onChange={(e) => setNewLogin({ ...newLogin, email: e.target.value })}
              />
            </div>
          </div>

          {/* Password */}
          <div className="mb-3">
            <div className="d-flex justify-content-between align-items-center">
              <label htmlFor="password" className="form-label mb-0">Password</label>
              <a href="#" className="text-decoration-none small">Forgot password?</a>
            </div>
            <div className="input-group">
              <span className="input-group-text">
                <i className="bi bi-lock"></i>
              </span>
              <input
                type='password'
                id="password"
                className="form-control"
                placeholder="Enter your password"
                value={newLogin.password}
                onChange={(e) => setNewLogin({ ...newLogin, password: e.target.value })}
              />
            </div>
          </div>


          <button onClick={handleLogin} type="submit" className="btn btn-dark w-100 mb-3">Sign in</button>

          {/* Divider */}
          <div className="text-center text-muted mb-3 mt-3">
            <hr />
            <span className="position-relative bg-white px-2" style={{ top: '-30px' }}>OR CONTINUE WITH</span>
          </div>

          {/* Social buttons */}
          <div className="d-flex gap-2 mb-3">
            <button type="button" className="btn btn-outline-secondary w-50">
              <i className="bi bi-google me-2"></i> Google
            </button>
            <button type="button" className="btn btn-outline-secondary w-50">
              <i className="bi bi-facebook me-2"></i> Facebook
            </button>
          </div>

          {/* Footer text */}
          <div className="text-center text-muted small">
            Don’t have an account? <a href="#" className="fw-medium text-decoration-none">Contact administrator</a>
          </div>
        </form>
      </div>
    </div>
  );
};
export default Login;