import { useComment } from './hooks/useComment';
import { formatDate } from '../../helpers/date';

import './styles/comment.css';

export const Comment = async (comment) => {	
    console.log("comment", comment);
	let view = `    
      <p>${comment.comment} </p>
      <div class="track"> 
        <span>${formatDate(comment.dateComment)}</span>
        <cite id="cite"></cite>
      </div>     
    `;

	return useComment(view, comment);
};
