import { NavBar, UserProfile } from "../../components";
import { user } from "../../Mock/user";
import { useAuthLayout } from "./hooks/useAuthLayout";

import "./styles/authLayout.css";

export const AuthLayout = (children) => {
  let view = `<header id="header">
                <div class="brand" id="">
                    &#60;TICKET-APP&#62;              
                </div>	                 
            </header>
            <aside>
                <nav class="navbar"> 
                    ${NavBar()} 
                </nav>  
            </aside>
            <main id="children"></main>
         `;

    return useAuthLayout(view, children);
};
