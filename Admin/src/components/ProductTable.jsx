import React from 'react'

const products = [
    { id: 1, name: 'Premium Headphones', category: 'Electronics', price: 199.99, stock: 45 },
    { id: 2, name: 'Ergonomic Chair', category: 'Furniture', price: 249.99, stock: 20 },
    { id: 3, name: 'Smartphone X', category: 'Electronics', price: 899.99, stock: 15 },
    { id: 4, name: 'Laptop Pro', category: 'Electronics', price: 1299.99, stock: 10 },
    { id: 5, name: 'Coffee Table', category: 'Furniture', price: 149.99, stock: 25 },
  ];
  

function ProductTable() {
  return (
    <div className="p-4">
    <div className="d-flex justify-content-between align-items-center mb-3">
      <h5>Products Management</h5>
      <button className="btn btn-dark">+ Add Product</button>
    </div>
    <input className="form-control mb-3" placeholder="Search products..." />
    <table className="table table-hover">
      <thead className="table-light">
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Category</th>
          <th>Price</th>
          <th>Stock</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {products.map(p => (
          <tr key={p.id}>
            <td>{p.id}</td>
            <td>{p.name}</td>
            <td>{p.category}</td>
            <td>${p.price.toFixed(2)}</td>
            <td>{p.stock}</td>
            <td>⋯</td>
          </tr>
        ))}
      </tbody>
    </table>
    <div className="d-flex justify-content-between align-items-center">
      <span>Showing 5 of 8 products</span>
      <div>
        <button className="btn btn-outline-secondary btn-sm me-2" disabled>Previous</button>
        <span>Page 1 of 2</span>
        <button className="btn btn-outline-secondary btn-sm ms-2">Next</button>
      </div>
    </div>
  </div>
  )
}

export default ProductTable