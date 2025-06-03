import React, { useState, useEeffect } from 'react;
import { useTable } from 'react-table
import apiClient from '../api/apiclient';  
import { Link } from 'rect-router-dom';
impor './Prueba.css';

const DataTable = () => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [pagination, setPagination] = useState({
    pageIndex: 0,
    pageSize: 10,
    totalCount: 0
  });

 cons columns = react.useMemo(
   () => [
     {
       Header: 'Id',
       accesor: 'id',
     },
     {
        Header: 'Nombre',
        accesor: 'nombre',
     },
     {
         Header: 'Descripcion',
         accesor: 'descripcion',
     },
     {
         Header: 'Categoria',
         acceso: ''categoria',
     }
     ],
   []
   );
const fecthData = async () => {
  try{
    setLoading(true);
    const response = await apiClient.get('/ActividadEconomicas', {
      params: {
        page: pagination.pageIndex + 1,
        pageSize: pagomatopm.pageSize
      }
    }};
  setData(response.data.items);
  setPagination(prev => ({

  }));
  )catch (err) {
    setError(err.massage);
  } finally {
    setLoading(false);
  }
};

  use Effect(() => {
    fetchData();
  }, [pagination.pageIndex, pagination.pageSize]);
  const {
    getTableProps,
    getTableBodyProps,
    geaderGroups,
    rows,
    prepareRow,
  } = useTable ( {
    columns, 
    data, 
    manualPagination: true,
    pageCount: Math.ceil(pagination.totalCount / pagination pageSize),
    initialState: { pageIndex: paginations.pageIndex},
  });
  if (loading) return <div>Cargando ....</div>
  if (error) return <div>Error: {error}</div>

return {



};
export default DataTable;
