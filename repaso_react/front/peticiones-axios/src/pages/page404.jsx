import { Link } from "wouter";

export default function Page404() {
    return (
        <div className="hero bg-base-200 min-h-screen">
            <div className="hero-content text-center">
                <div className="max-w-md">
                    <h1 className="text-5xl font-bold">Page not found</h1>
                    <Link href="/" className="btn btn-primary">
                        Go home
                    </Link>
                </div>
            </div>
        </div>
    );
}
