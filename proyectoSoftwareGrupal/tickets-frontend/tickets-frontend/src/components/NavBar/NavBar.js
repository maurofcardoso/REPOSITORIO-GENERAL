import './styles/navbar.css';
import { getStorage } from "../../helpers/storage";

export const NavBar = () => {
    const user = getStorage("tickets_user");

    if(!!user && user.rol.rolId == 1)
  	{
        var btnAreas = `<button>Areas</button>  `
        var btnCategorias = `<button>Categorias</button>`
        var btnUsuarios = `<button>Usuarios</button>`
    }
    else
    {
        var btnAreas = ``
        var btnCategorias = ``
        var btnUsuarios = ``
    }

	return `<button>Inicio</button>                
            <button>MisTickets</button>              
            ${btnAreas}
            ${btnCategorias}
            ${btnUsuarios}     
            `;
};




