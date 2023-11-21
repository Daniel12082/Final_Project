const entitiesDropdown = document.getElementById('entitiesDropdown');
const entityQueriesDropdown = document.getElementById('entityQueriesDropdown');
let selectedQueryId = null; // Variable para almacenar el ID seleccionado

entitiesDropdown.addEventListener('change', function() {
    const selectedEntity = entitiesDropdown.value;
    console.log(selectedEntity)
    // Lógica para cargar las opciones según la entidad seleccionada
    let options = [];
        switch (selectedEntity) {
            case 'boss':
                options = ['Option 1 for Boss', 'Option 2 for Boss', 'Option 3 for Boss'];
                break;
            case 'city':
                options = ['Option 1 for City', 'Option 2 for City', 'Option 3 for City'];
                break;
            case 'client':
                options = ['Option 1 for Client', 'Option 2 for Client', 'Option 3 for Client'];
                break;
            case 'contact':
                options = ['Option 1 for Contact', 'Option 2 for Contact', 'Option 3 for Contact'];
                break;
            case 'country':
                options = ['Option 1 for Country', 'Option 2 for Country', 'Option 3 for Country'];
                break;
            case 'employee':
                options = ['Option 1 for Employee', 'Option 2 for Employee', 'Option 3 for Employee'];
                break;
            case 'office':
                options = ['Option 1 for Office', 'Option 2 for Office', 'Option 3 for Office'];
                break;
            case 'order':
                options = ['Option 1 for Order', 'Option 2 for Order', 'Option 3 for Order'];
                break;
            case 'payment':
                options = ['Option 1 for Payment', 'Option 2 for Payment', 'Option 3 for Payment'];
                break;
            case 'product':
                options = ['Option 1 for Product', 'Option 2 for Product', 'Option 3 for Product'];
                break;
            case 'provider':
                options = ['Option 1 for Provider', 'Option 2 for Provider', 'Option 3 for Provider'];
                break;
            case 'state':
                options = ['Option 1 for State', 'Option 2 for State', 'Option 3 for State'];
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