import Head from 'next/head';
import PrincipalLayout from "../layouts/Principal/PrincipalLayout";


export default function Home() {
  return (
    <div>
      <Head>
        <link rel="shortcut icon" href="favicon.ico"/>
        <title>Currency Exchange</title>
      </Head>
      <PrincipalLayout pagina = "search"/>

    </div>
  )
}