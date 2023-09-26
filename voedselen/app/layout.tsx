import "./globals.css";
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import { Footer } from "./menu/page";
import { Montserrat, Montserrat_Alternates } from "next/font/google";
import next from "next";

const montserrat = Montserrat_Alternates({
  weight: "400",
  subsets: ["latin-ext"],
});

export const metadata: Metadata = {
  title: "Voedselen",
  description: "S3DB04 Voedselen App",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <html lang="en">
        <body className={montserrat.className}>
          {children}
        <Footer></Footer>
        </body>
      </html>
    </>
  );
}
