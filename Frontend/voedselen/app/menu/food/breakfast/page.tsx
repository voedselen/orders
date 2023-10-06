import Link from 'next/link';
import styles from './page.module.css'
import Image from 'next/image';
import sandwich from '../../../../public/menu_breakfast_sandwich.jpg';
import soup from '../../../../public/menu_breakfast_soup.jpg';

import MenuCard from '@/public/components/molecules/menucard';
 
 

export default function Breakfast() {
    return (
     
<>

        <div className={styles.main_div}>
        <Link className={styles.link} href={'/menu/food'}>Back</Link>
          <MenuCard href={"/menu/food/breakfast/sandwiches"}>
            <Image id={styles.menucard_image} src={sandwich} alt={"sandwich"}></Image>
            <div className={styles.menucard_text}>Sandwiches</div>
          </MenuCard>
          <MenuCard href={"/menu/food/breakfast/soups"}>
            <Image id={styles.menucard_image} src={soup} alt={"soup"}></Image>
            <div className={styles.menucard_text}>Soups</div>
          </MenuCard>
         </div>
         </>
    )
}