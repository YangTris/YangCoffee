import React, { useEffect, useState } from "react";
import {
  getAllCategories,
  deleteCategory,
  addCategory,
  getCategoryById,
  updateCategory,
} from "../api/categoryApi";

function CategoryTable() {
  // Get all categories
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadCategories = async () => {
      try {
        const data = await getAllCategories();
        setCategories(data);
      } catch (error) {
        console.error("Failed to fetch categories", error);
      } finally {
        setLoading(false);
      }
    };

    loadCategories();
  }, []);

  // Add new category
  const [newCategory, setNewCategory] = useState({
    categoryId: "",
    name: "",
    description: "",
  });
  const [showModal, setShowModal] = useState(false);

  // Edit category
  const [editCategory, setEditCategory] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);

  // Handle edit button click
  const handleEdit = async (categoryId) => {
    try {
      const category = await getCategoryById(categoryId); // Fetch category by ID
      setEditCategory(category);
      setShowEditModal(true);
    } catch (error) {
      console.error("Failed to fetch category", error);
    }
  };

  // Handle update category
  const handleUpdate = async () => {
    try {
      await updateCategory(editCategory.categoryId, editCategory);
      const data = await getAllCategories();
      setCategories(data);
      setShowEditModal(false);
      setEditCategory(null);
    } catch (error) {
      console.error("Failed to update category", error);
    }
  };

  return (
    <div className="p-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h5>Categories Management</h5>
        <button className="btn btn-dark" onClick={() => setShowModal(true)}>
          + Add Category
        </button>
      </div>

      {/* Add Category Modal */}
      {showModal && (
        <div
          className="modal fade show d-block"
          tabIndex="-1"
          role="dialog"
          onClick={() => setShowModal(false)}
          style={{ backgroundColor: "rgba(0,0,0,0.5)" }}
        >
          <div className="modal-dialog" role="document" onClick={(e) => e.stopPropagation()}>
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Add New Category</h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowModal(false)}
                ></button>
              </div>
              <div className="modal-body">
                <div className="mb-3">
                  <input type="hidden" value={newCategory.categoryId} />
                  <label className="form-label">Name</label>
                  <input
                    type="text"
                    className="form-control"
                    value={newCategory.name}
                    onChange={(e) =>
                      setNewCategory({ ...newCategory, name: e.target.value })
                    }
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Description</label>
                  <input
                    type="text"
                    className="form-control"
                    value={newCategory.description}
                    onChange={(e) =>
                      setNewCategory({
                        ...newCategory,
                        description: e.target.value,
                      })
                    }
                  />
                </div>
              </div>
              <div className="modal-footer">
                <button
                  className="btn btn-primary"
                  onClick={async () => {
                    try {
                      await addCategory(newCategory);
                      const data = await getAllCategories();
                      setCategories(data);
                      setShowModal(false);
                      setNewCategory({ categoryId: "", name: "", description: "" });
                    } catch (error) {
                      console.error("Failed to add category", error);
                    }
                  }}
                >
                  Save
                </button>
                <button
                  className="btn btn-secondary"
                  onClick={() => setShowModal(false)}
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )}

      {/* Edit Category Modal */}
      {showEditModal && editCategory && (
        <div
          className="modal fade show d-block"
          tabIndex="-1"
          role="dialog"
          onClick={() => {
            setShowEditModal(false);
            setEditCategory(null);
          }}
          style={{ backgroundColor: "rgba(0,0,0,0.5)" }}
        >
          <div className="modal-dialog" role="document" onClick={(e) => e.stopPropagation()}>
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Edit Category</h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowEditModal(false)}
                ></button>
              </div>
              <div className="modal-body">
                <div className="mb-3">
                  <input type="hidden" value={editCategory.categoryId} />
                  <label className="form-label">Name</label>
                  <input
                    type="text"
                    className="form-control"
                    value={editCategory.name}
                    onChange={(e) =>
                      setEditCategory({ ...editCategory, name: e.target.value })
                    }
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Description</label>
                  <input
                    type="text"
                    className="form-control"
                    value={editCategory.description}
                    onChange={(e) =>
                      setEditCategory({
                        ...editCategory,
                        description: e.target.value,
                      })
                    }
                  />
                </div>
              </div>
              <div className="modal-footer">
                <button className="btn btn-primary" onClick={handleUpdate}>
                  Update
                </button>
                <button
                  className="btn btn-secondary"
                  onClick={() => setShowEditModal(false)}
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )}

      <input className="form-control mb-3" placeholder="Search categories..." />
      {loading ? (
        <p>Loading categories...</p>
      ) : (
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
              <tr key={c.categoryId}>
                <td>{c.categoryId}</td>
                <td>{c.name}</td>
                <td>{c.description}</td>
                <td>
                  <button
                    className="btn btn-sm btn-primary me-2"
                    onClick={() => handleEdit(c.categoryId)}
                  >
                    Edit
                  </button>
                  <button
                    className="btn btn-sm btn-danger"
                    onClick={async () => {
                      if (window.confirm(`Delete category "${c.name}"?`)) {
                        try {
                          await deleteCategory(c.categoryId);
                          setCategories(
                            categories.filter(
                              (cat) => cat.categoryId !== c.categoryId
                            )
                          );
                        } catch (error) {
                          console.error("Failed to delete category", error);
                        }
                      }
                    }}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default CategoryTable;