import { useModal } from './hooks/useModal';
import './styles/modal.css';

export const Modal = async (children) => {	
	let view = ` 
        <div class="modal-contain">
            <div id="childrenModal"></div>
        </div>      
    `;

	return useModal(view, children);
};
