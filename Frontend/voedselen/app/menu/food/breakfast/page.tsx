import Link from 'next/link';
import styles from './page.module.css'
import Image from 'next/image';
import sandwich from '../../../../public/menu_breakfast_sandwich.jpg';
import soup from '../../../../public/menu_breakfast_soup.jpg';

export function BreakfastCardSandwiches() {
    return (
      <Link href={"/menu/food/breakfast/sandwiches"}>
        <div className={styles.menucard_wrapper}>
          <Image
            id={styles.menucard_image}
            src={sandwich}
            alt={"sandwiches"}
          ></Image>
  
          <div className={styles.menucard_text}>Sandwiches</div>
        </div>
      </Link>
    );
  }
export function BreakfastCardSoups() {
    return (
      <Link href={"/menu/food/breakfast/soups"}>
        <div className={styles.menucard_wrapper}>
          <Image
            id={styles.menucard_image}
            src={soup}
            alt={"soups"}
          ></Image>
  
          <div className={styles.menucard_text}>Soups</div>
        </div>
      </Link>
    );
  }



export default function Breakfast() {
    return (
        <div className={styles.main_div}>
             
            <BreakfastCardSandwiches></BreakfastCardSandwiches>
            <BreakfastCardSoups></BreakfastCardSoups>
        </div>
    )
}