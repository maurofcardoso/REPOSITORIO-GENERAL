import { Layout, header, navMenu, divMain, BannerIzq, BannerDer } from "../Components/LayoutComponent.js";

export const LayoutIndex = () => {
    const ApplicationWeb = document.getElementById ('ApplicationWeb');
    ApplicationWeb.innerHTML = Layout();
    const headers = document.getElementById ('search');
    headers.innerHTML = header();
    const navigation = document.getElementById ('menu');
    if (localStorage.getItem ("active") == "true") {
        navigation.innerHTML = navMenu();
        const _activeLogo = document.getElementById ("carritoLogo");
        _activeLogo.classList.add ("active");
    }else {
        navigation.innerHTML = navMenu();
        const _activeLogo = document.getElementById ("carritoLogo");
        _activeLogo.classList.remove("active");
    }
    const Main = document.getElementById ("main");
    Main.innerHTML = divMain ();
    const banIzq = document.getElementById ("bannerIzq");
    banIzq.innerHTML = BannerIzq ();
    const banDer = document.getElementById ("bannerDer");
    banDer.innerHTML = BannerDer ();
}