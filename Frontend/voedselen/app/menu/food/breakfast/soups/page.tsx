import Link from 'next/link';
import styles from './page.module.css';


export default function Soups() {
    return (
        <>
        <Link href={'/menu/food/breakfast'}>Back</Link>
        <main className={styles.main}>
            <h1>Soups</h1>
        </main>
        </>
    )
}