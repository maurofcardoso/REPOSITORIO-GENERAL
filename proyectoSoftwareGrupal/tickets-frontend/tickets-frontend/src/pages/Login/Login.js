import { useLogin } from './hooks/useLogin';
import './styles/login.css';

export const Login = async() => {
    let view = `
        <div class="brand" >
            <h1>Login</h1>
            &#60;TICKET-APP&#62;              
        </div>
        <input type="text" placeholder="Usuario" id="user"/>
        <input type="password" placeholder="Password" id="password" />
        <button class="btn" id="btnLogin" > Ingresar </button> 
    `;  
    
    return useLogin(view);    
} 