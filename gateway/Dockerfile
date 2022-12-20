FROM curlimages/curl

COPY build-services.sh /tmp/build-services.sh

WORKDIR /tmp/

USER root
RUN chmod +x ./build-services.sh
USER 1001

# RUN ./build-services.sh

ENTRYPOINT [ "/tmp/build-services.sh" ]