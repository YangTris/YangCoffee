import React from "react";

const categories = [
  { id: 1, name: "Electronics", description: "Devices and gadgets" },
  { id: 2, name: "Furniture", description: "Home and office furniture" },
  { id: 3, name: "Appliances", description: "Home appliances" },
];

function CategoryTable() {
  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Categories Management</h5>
        <button className="btn btn-dark">+ Add Category</button>
      </div>
      <input className="form-control mb-3" placeholder="Search categories..." />
      <table className="table table-hover">
        <thead className="table-light">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((c) => (
            <tr key={c.id}>
              <td>{c.id}</td>
              <td>{c.name}</td>
              <td>{c.description}</td>
              <td>
                <button className="btn btn-sm btn-primary me-2">Edit</button>
                <button className="btn btn-sm btn-danger">Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default CategoryTable;
