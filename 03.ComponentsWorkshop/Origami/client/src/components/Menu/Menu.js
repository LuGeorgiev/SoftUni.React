import {useState} from 'react';
import MenuItem from './MenuItem/MenuItem';

import './Menu.css';
import { menuItems} from './menuConstants';


const Menu = (props) =>{
    const [currentItem, setcurrentItem] = useState();
    return(
        <ul className="menu">
            {menuItems.map(item =>
                <MenuItem 
                    key={item.id} 
                    id={item.id}
                    isSelected={item.id === currentItem } 
                    onClick={setcurrentItem}
                >
                    {item.text}
                </MenuItem>
            )}
        </ul>
    );
}

export default Menu;