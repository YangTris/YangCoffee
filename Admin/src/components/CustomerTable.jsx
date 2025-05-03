import React from 'react'

const customers = [
    { id: 1, name: 'Alice Johnson', email: 'alice@example.com' },
    { id: 2, name: 'Bob Smith', email: 'bob@example.com' },
    { id: 3, name: 'Charlie Brown', email: 'charlie@example.com' },
  ];

function CustomerTable() {
  return (
    <div className="p-4">
    <div className="d-flex justify-content-between align-items-center mb-3">
      <h5>Customers Management</h5>
    </div>
    <input className="form-control mb-3" placeholder="Search customers..." />
    <table className="table table-hover">
      <thead className="table-light">
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Email</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {customers.map((c) => (
          <tr key={c.id}>
            <td>{c.id}</td>
            <td>{c.name}</td>
            <td>{c.email}</td>
            <td>⋯</td>
          </tr>
        ))}
      </tbody>
    </table>
    <div className="d-flex justify-content-between align-items-center">
      <span>Showing 5 of 8 customers</span>
      <div>
        <button className="btn btn-outline-secondary btn-sm me-2" disabled>Previous</button>
        <span>Page 1 of 2</span>
        <button className="btn btn-outline-secondary btn-sm ms-2">Next</button>
      </div>
    </div>
  </div>
  )
}

export default CustomerTable