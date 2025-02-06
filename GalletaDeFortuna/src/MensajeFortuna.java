public class MensajeFortuna implements MensajeGalleta {
    private String mensaje;

    public MensajeFortuna(String mensaje) {
        this.mensaje = mensaje;
    }

    @Override
    public MensajeGalleta clone() {
        return new MensajeFortuna(this.mensaje);
    }

    @Override
    public String getMensaje() {
        return mensaje;
    }
}