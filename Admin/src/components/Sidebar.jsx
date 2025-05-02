import React from "react";

function Sidebar() {
  return (
    <div
      className="d-flex flex-column p-3 bg-light min-vh-100"
      style={{ width: "250px" }}
    >
      <h4 className="mb-4">Admin Panel</h4>
      <ul className="nav nav-pills flex-column mb-auto">
        <li className="nav-item">
          <a href="#" className="nav-link active">
            Dashboard
          </a>
        </li>
        <li>
          <a href="#" className="nav-link">
            Products
          </a>
        </li>
        <li>
          <a href="#" className="nav-link">
            Categories
          </a>
        </li>
        <li>
          <a href="#" className="nav-link">
            Customers
          </a>
        </li>
        <li>
          <a href="#" className="nav-link">
            Settings
          </a>
        </li>
      </ul>
      <div className="mt-auto">
        <button className="btn btn-outline-secondary w-100">Log out</button>
      </div>
    </div>
  );
}

export default Sidebar;
