import style from './Book.module.css';

function Book(props){
    
    if(!props.title){
        return(
            <article>
                <p>No information provided</p>
            </article>
        )
    }
    const author = props.author ? <strong>{props.author}</strong> : <strong>Pesho</strong>;

    return (
        <article className={style.article}>
            <h3 onClick={props.clickHandler}>{props.title}</h3>
            <span className={style.description}>{props.description || 'Default descripton'}</span>
            <p className={style.author}>{author}</p>
        </article>
    );
}

export default Book;