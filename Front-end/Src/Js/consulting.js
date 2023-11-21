const entitiesDropdown = document.getElementById('entitiesDropdown');
const entityQueriesDropdown = document.getElementById('entityQueriesDropdown');
let selectedQueryId = null; // Variable para almacenar el ID seleccionado

entitiesDropdown.addEventListener('change', function() {
    const selectedEntity = entitiesDropdown.value;
    console.log(selectedEntity)
    // Lógica para cargar las opciones según la entidad seleccionada
    let options = [];
        switch (selectedEntity) {
            case 'client':
                options = ['Ubicados en españa', 'Pagos en 2008', 'Ubicado en madrid y con empleado con id 11','Datos de los clientes y representante de ventas','Cliente que han hecho pagos y nombre su representante','Cliente que no han hecho pagos y nombre su representante','Cliente que han hecho pagos, nombre su representante y ciudad de la oficina del representante','Cliente que no han hecho pagos, nombre su representante y ciudad de la oficina del representante','Nombre, representante y ciudad de la oficina','Nombre s a los que no se les ha entregado a tiempo un pedido','No han realizado pagos','Sin pedidos','Sin pago y sin pedidos','Con pedido pero sin pago'];
                break;
            case 'employee':
                options = ['Codigo del jefe nro 7', 'Cargos', 'No son representante de ventas','Nombre de sus jefes','Jefe y jefe de su jefe','Sin oficina','Sin clientes','Sin clientes y los datos de su oficina','Sin oficina y sin clientes','Sin clientes y su jefe','Empleados totales','Nombre de los represena de ventay cuantos clientes tiene','Empleados que estan a cargo de ------','Datos de Empleados que no representan clientes'];
                break;
            case 'office':
                options = ['Ciudad donde estan ubicadas', 'Ubicado en españa y sus telefonos', 'Direcciones que tengan clientes en ---------','Sin empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales','Nombre de empleados que no sean  representante de ventas','Ciudades y numero de empleados'];
                break;
            case 'order':
                options = ['Estados de un pedido', 'Codigo del pedido,cliente, fecha de espera y fecha de entrega', 'Codigo,Cliente,Fecha de espera y fecha de entrega de los pedidos cuya fecha de entrega ha sido al menos dos días antes de la fecha esperada.','Estado rechazados','Pedido entregado en meses de enero'];
                break;
            case 'payment':
                options = ['Pagos del 2008 por Paypal', 'Formas de pago'];
                break;
            case 'product':
                options = ['Productos de la gama ornamental y que tienen más de 100 unidades en stock', 'Gamas de los productos', 'Productos que nunca han comprado','Productos que nunca han comprado','Producto mas caro'];
                break;
            default:
                options = ['Default Option 1', 'Default Option 2', 'Default Option 3'];
                break;
        }

    // Limpiar opciones actuales del segundo dropdown
    entityQueriesDropdown.innerHTML = '';

    // Agregar las nuevas opciones al segundo dropdown
    options.forEach(optionText => {
        const option = document.createElement('option');
        option.text = optionText;
        entityQueriesDropdown.add(option);
    });
});
entityQueriesDropdown.addEventListener('change', function() {
    const selectedIndex = entityQueriesDropdown.selectedIndex;
    selectedQueryId = (selectedIndex+1);
    console.log(selectedQueryId);
    // ... Realizar otras acciones con el índice seleccionado ...
});