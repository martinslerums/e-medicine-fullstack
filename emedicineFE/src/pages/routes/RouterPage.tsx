import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../LoginPage";
import RegistrationPage from "../RegistrationPage";
import Dashboard from "../../components/users/Dashboard";
import Orders from "../../components/users/Orders";
import Profile from "../../components/users/Profile";
import Cart from "../../components/users/Cart";
import AdminDashboard from "../../components/admin/AdminDashboard";
import CustomerList from "../../components/admin/CustomerList";
import Medicine from "../../components/admin/Medicine";
import MedicineDisplay from "../../components/users/MedicineDisplay";
import AdminOrders from "../../components/admin/AdminOrders";

const RouterPage = () => {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegistrationPage />} />
        <Route path="/dashboard" element={<Dashboard />} />
        <Route path="/my-orders" element={<Orders />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/cart" element={<Cart />} />
        <Route path="/products" element={<MedicineDisplay />} />

        <Route path="/admin-dashboard" element={<AdminDashboard />} />
        <Route path="/admin-orders" element={<AdminOrders />} />
        <Route path="/customers" element={<CustomerList />} />
        <Route path="/medicine" element={<Medicine />} />
      </Routes>
    </Router>
  );
};

export default RouterPage;
