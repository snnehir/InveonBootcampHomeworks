import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Navigate, Outlet } from 'react-router-dom'
export const ProtedtedRoutes = () => {
  let status = useSelector((state) => state.user.status);
  return (
    status ? <Outlet /> : <Navigate to='/' />
  )
}

