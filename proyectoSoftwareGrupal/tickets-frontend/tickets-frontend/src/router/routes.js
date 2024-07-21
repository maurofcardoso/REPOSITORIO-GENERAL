import { AuthLayout, PublicLayout } from "../layouts";
import { Home, Login, NotFound, ViewTicket, Tickets, Unauthorized, NewTicket, MisTickets, Areas, NewArea, Categorias, NewCategoria} from "../pages";
import { NewUsuario } from "../pages/newUsuarios/NewUsuario.js";
import { Usuarios } from "../pages/Usuarios/Usuarios.js";

export const routes = [
  {
    path: "/",
    page: () => AuthLayout(async () => await Home()),
  },
  {
    path: "/inicio",
    page: () => AuthLayout(async () => await Home()),
  },
  {
    path: "/home",
    page: () => AuthLayout(async () => await Home()),
  },
  {
    path: "/login",
    page: () => PublicLayout(() => Login()),
  },
  {
    path: "/tickets",
    page: () => AuthLayout(async () => await Tickets()),
  },
  {
    path: "/tickets/:id",
    page: (params) => AuthLayout(async () => await ViewTicket(params)),
  },
  {
    path: "/newticket",
    page: (params) => AuthLayout(async () => await NewTicket(params)),
  },
  {
    path: "/mistickets",
    page: (params) => AuthLayout(async () => await MisTickets(params)),
  },
  {
    path: "/nuevo",
    page: (params) => AuthLayout(async () => await NewTicket(params)),
  },
  {
    path: "/areas",
    page: () => AuthLayout(async () => await Areas()),
  },
  {
    path: "/newarea",
    page: (params) => AuthLayout(async () => await NewArea(params)),
  },
  {
    path: "/categorias",
    page: () => AuthLayout(async () => await Categorias()),
  },
  {
    path: "/newcategoria",
    page: (params) => AuthLayout(async () => await NewCategoria(params)),
  },
  {
    path: "/usuarios",
    page: () => AuthLayout(async () => await Usuarios()),
  },
  {
    path: "/newusuario",
    page: (params) => AuthLayout(async () => await NewUsuario(params)),
  },
  {
		path: '/unauthorized',
		page: () => PublicLayout(Unauthorized),
	},
  
];

export const routeNotFound = {
  path: "/notfound",
  page: () => PublicLayout(NotFound),
};
