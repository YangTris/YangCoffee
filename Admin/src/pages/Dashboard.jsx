import React from 'react'
import ProductTable from '../components/ProductTable'

function Dashboard() {
  return (
    <div className="flex-grow-1 bg-white">
    <div className="p-4 border-bottom">
      <h3>Admin Dashboard</h3>
      <ul className="nav nav-tabs mt-3">
        <li className="nav-item">
          <a className="nav-link active" href="#">Products</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="#">Categories</a>
        </li>
        <li className="nav-item">
          <a className="nav-link" href="#">Customers</a>
        </li>
      </ul>
    </div>
    <ProductTable />
  </div>
  )
}

export default Dashboard